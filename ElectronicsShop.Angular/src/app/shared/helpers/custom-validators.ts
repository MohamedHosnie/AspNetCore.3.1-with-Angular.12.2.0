import { FormControl, ValidationErrors } from "@angular/forms";

export class CustomValidators {
  static AgeMoreThanThirteen(control: FormControl): { [key: string]: any } | null {
    let date: Date = new Date();
    let minimumYear = date.getFullYear() - 13;
    date.setFullYear(minimumYear);

    if (new Date(control.value) > date) {
      return { "AgeMoreThanThirteen": true };
    }

    return null;
  }
  static Date(control: FormControl): { [key: string]: any } | null {
    if (control.value === "" || control.value == null) {
      return null;
    }
    if ((new Date(control.value) as any !== "Invalid Date") && !isNaN(new Date(control.value) as any)) {
      return null;
    }

    return { "Date": true }
  }
}
