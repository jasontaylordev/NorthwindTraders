import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'firstLetterUpperCase'
})
export class FirstLetterUpperCasePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (!value) {
      return value;
    }

    if (value.split(' ').length <= 1) {
      return this.upFirstLetter(value);
    }

    const splitValue: string[] = value.toLowerCase().split(' ');
    const newValue: string = splitValue.map(val => {
      return this.upFirstLetter(val);
    }).join(' ');
    return newValue;
  }


  private upFirstLetter(val: string): string {
    return val.substring(0, 1).toUpperCase() + val.substring(1);
  }
}
