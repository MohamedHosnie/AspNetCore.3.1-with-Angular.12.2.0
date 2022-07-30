import { Injectable, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CreateOrderDto, Exception, OrderDto, OrderServiceProxy, ProductDto } from '../../service-proxies/service-proxies';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  product!: ProductDto;

  constructor(
    private orderServiceProxy: OrderServiceProxy,
    private toastr: ToastrService
  ) { }

  createOrder(order: CreateOrderDto) {
    return new Promise<number>((resolve, reject) => {
      this.orderServiceProxy.create(order).subscribe((result: number) => {
        resolve(result);
        this.toastr.success("Added successfully!!", "Success!!");
      }, (error: Exception) => {
        this.toastr.error(error.response, "Something is wrong");
        reject(error);
      });
    });
  }

  getAllOrders() {
    return new Promise<OrderDto[]>((resolve, reject) => {
      this.orderServiceProxy.getAll().subscribe((result: OrderDto[]) => {
        resolve(result);
      }, (error: Exception) => {
        this.toastr.error(error.response, "Something is wrong");
        reject(error);
      });
    });
  }

}
