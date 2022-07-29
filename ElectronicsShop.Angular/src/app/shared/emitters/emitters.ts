import { EventEmitter } from "@angular/core";
import { GetLoggedInUserDto } from "../service-proxies/service-proxies";


export class Emitters {
  static authEmitter = new EventEmitter<boolean>();
  static userDataEmitter = new EventEmitter<GetLoggedInUserDto | null>();
}
