import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { CategoryDto } from '../../shared/service-proxies/service-proxies';
import { ProductService } from '../../shared/services/products/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {

  form!: FormGroup;
  categories!: CategoryDto[];

  constructor(
    private titleService: Title,
    private productService: ProductService,
    private router: Router,
    private location: Location
  ) {
    this.titleService.setTitle("Create Product");
  }

  ngOnInit(): void {
    this.productService.getCategories().then((result: CategoryDto[]) => {
      this.categories = result;
    });

    this.form = new FormGroup({
      name: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(40)
      ]),
      description: new FormControl("", [
        Validators.required,
        Validators.minLength(5),
        Validators.maxLength(50)
      ]),
      price: new FormControl("", [
        Validators.required,
        Validators.min(0)
      ]),
      discount: new FormControl(""),
      discountontwo: new FormControl(""),
      categoryid: new FormControl("", [
        Validators.required
      ])
    });
  }

  submit() {
    if (this.form.valid === false) {
      this.form.markAllAsTouched()
      return;
    }

    let formData = this.form.getRawValue();
    formData.categoryid = parseInt(formData.categoryid);
    this.productService.createProduct(formData).then((result: number) => {
      if (result > -1) {
        this.back();
      }
    });
  }

  back() {
    this.location.back();
  }

}
