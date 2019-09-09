import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'camelCaseToText'
})
export class CamelCaseToText implements PipeTransform {

    transform(value: any, args?: any): any {
        if (!value) {
            return value;
        }

        const splitByCamelCase: string[] = value.match(/[A-Z][a-z]+|[a-z]+/g);
        if (splitByCamelCase.length <= 1) {
            value = this.upFirstLetter(value);
        } else {
            value = splitByCamelCase.map(val => {
                return this.upFirstLetter(val);
            }).join(' ');
        }
        return value;
    }


    private upFirstLetter(val: string): string {
        return val.substring(0, 1).toUpperCase() + val.substring(1);
    }
}
