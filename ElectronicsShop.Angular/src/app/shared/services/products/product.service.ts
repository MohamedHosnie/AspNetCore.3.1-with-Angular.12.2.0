import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CategoryDto, CreateProductDto, Exception, ProductDto, ProductServiceProxy } from '../../service-proxies/service-proxies';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(
    private _productServiceProxy: ProductServiceProxy,
    private toastr: ToastrService
  ) { }

  getCategories() {
    return new Promise<CategoryDto[]>((resolve, reject) => {
      this._productServiceProxy.categories().subscribe((result: CategoryDto[]) => {
        resolve(result);
      }, (error: Exception) => {
        reject(error);
      });
    })
  }

  createProduct(product: CreateProductDto) {
    return new Promise<number>((resolve, reject) => {
      this._productServiceProxy.create(product).subscribe((result: number) => {
        resolve(result);
        this.toastr.success("Added successfully!!", "Success!!");
      }, (error: Exception) => {
        this.toastr.error(error.response, "Something is wrong");
        reject(error);
      });
    })
  }

  getAllProducts() {
    return new Promise<ProductDto[]>((resolve, reject) => {
      this._productServiceProxy.getAll().subscribe((result: ProductDto[]) => {
        resolve(result);
      }, (error: Exception) => {
        this.toastr.error(error.response, "Something is wrong");
        reject(error);
      });
    });
  }

}
