import { EventEmitter } from "@angular/core";
import { UserDto } from "../service-proxies/service-proxies";


export class Emitters {
  static authEmitter = new EventEmitter<boolean>();
  static userDataEmitter = new EventEmitter<UserDto | null>();
  static unauthEmitter = new EventEmitter();
}
