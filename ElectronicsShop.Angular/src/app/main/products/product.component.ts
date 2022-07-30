import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryDto, ProductDto } from '../../shared/service-proxies/service-proxies';
import { ProductService } from '../../shared/services/products/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  config: any;
  collection!: ProductDto[];
  categories!: CategoryDto[];
  filteredCollection!: ProductDto[];
  category = -1;

  constructor(
    private titleService: Title,
    private productService: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {

    this.titleService.setTitle("Products");

    this.config = {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: 0
    };

    route.queryParams.subscribe((params) => {
      this.config.currentPage = params['page'] ? params['page'] : 1;
    });

  }

  ngOnInit(): void {
    this.productService.getCategories().then((result: CategoryDto[]) => {
      this.categories = result;
    });

    this.productService.getAllProducts().then((result: ProductDto[]) => {
      this.collection = result;
      this.filteredCollection = result;
    });


  }

  pageChange(newPage: number) {
    this.router.navigate(['product'], { queryParams: { page: newPage } });
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


}
