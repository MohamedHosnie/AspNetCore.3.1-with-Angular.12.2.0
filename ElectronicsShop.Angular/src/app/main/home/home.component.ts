import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Emitters } from '../../shared/emitters/emitters';
import { CategoryDto, ProductDto, UserDto } from '../../shared/service-proxies/service-proxies';
import { OrderService } from '../../shared/services/orders/order.service';
import { ProductService } from '../../shared/services/products/product.service';
import { SessionService } from '../../shared/services/session/session.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  isAuthenticated = false;

  config: any;
  collection!: ProductDto[];
  categories!: CategoryDto[];
  filteredCollection!: ProductDto[];
  category = -1;

  constructor(
    private titleService: Title,
    private sessionService: SessionService,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router,
    private orderService: OrderService

  ) {
    this.titleService.setTitle("Discover Products");

    this.config = {
      currentPage: 1,
      itemsPerPage: 6,
      totalItems: 0
    };

    route.queryParams.subscribe((params) => {
      this.config.currentPage = params['page'] ? params['page'] : 1;
    });
  }

  ngOnInit(): void {

    let user = this.sessionService.user as UserDto;
    if (user != null) {
      this.isAuthenticated = true;
    }

    Emitters.userDataEmitter.subscribe(user => {
      if (user != null) {
        this.isAuthenticated = true;
      } else {
        this.isAuthenticated = false;
      }

    });

    this.productService.getCategories().then((result: CategoryDto[]) => {
      this.categories = result;
    });

    this.productService.getAllProducts().then((result: ProductDto[]) => {
      this.collection = result;
      this.filteredCollection = result;
    });

  }

  pageChange(newPage: number) {
    this.router.navigate(['/'], { queryParams: { page: newPage } });
  }

  categoryChange() {
    if (this.category == -1) {
      this.filteredCollection = this.collection;
      return;
    }
    this.filteredCollection = this.collection.filter(item => {
      return item.categoryId == this.category;
    });

    this.config.currentPage = 1;
    this.pageChange(1);
  }

  order(product: ProductDto) {
    this.orderService.product = product;
    this.router.navigate(['order/create']);
  }

}
