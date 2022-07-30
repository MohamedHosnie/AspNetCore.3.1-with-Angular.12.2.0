import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderDto } from '../../shared/service-proxies/service-proxies';
import { OrderService } from '../../shared/services/orders/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  config: any;
  collection!: OrderDto[];

  constructor(
    private titleService: Title,
    private orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.titleService.setTitle("Orders");

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
    this.orderService.getAllOrders().then((result: OrderDto[]) => {
      this.collection = result;
    });

  }

  pageChange(newPage: number) {
    this.router.navigate(['order'], { queryParams: { page: newPage } });
  }



}
