import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductDto } from '../../shared/service-proxies/service-proxies';
import { OrderService } from '../../shared/services/orders/order.service';

@Component({
  selector: 'app-create-order',
  templateUrl: './create-order.component.html',
  styleUrls: ['./create-order.component.css']
})
export class CreateOrderComponent implements OnInit {

  product!: ProductDto;
  form!: FormGroup;
  userId!: number;
  totalPrice: number = 0.00;
  quantity: number = 1;

  quantityMod2: number = 1;
  quantityOver2: number = 0;

  constructor(
    private orderService: OrderService,
    private router: Router,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.product = this.orderService.product;

    if (this.product == null) {
      this.router.navigate(["/"]);
      return;
    }

    this.totalPrice = this.product.price;

    this.form = new FormGroup({
      productId: new FormControl(""),
      quantity: new FormControl("", [
        Validators.required,
        Validators.min(1)
      ])
    });

    this.form.controls.quantity.setValue(1);
    this.form.controls.productId.setValue(this.product.id);

  }

  submit() {
    if (this.form.valid === false) {
      this.form.markAllAsTouched()
      return;
    }

    this.orderService.createOrder(this.form.getRawValue()).then((result: number) => {
      if (result > -1) {
        this.back();
      }
    });
  }

  back() {
    this.location.back();
  }

  quantityChange() {
    this.quantity = this.form.controls.quantity.value;
    this.quantityMod2 = Math.trunc(this.quantity % 2);
    this.quantityOver2 = Math.trunc(this.quantity / 2);
    this.totalPrice = ((this.product.priceOfTwo == null ? this.quantity : this.quantityMod2) * this.product.price)
      + (this.quantityOver2 * (this.product.priceOfTwo == null ? 0 : this.product.priceOfTwo));
  }

}
