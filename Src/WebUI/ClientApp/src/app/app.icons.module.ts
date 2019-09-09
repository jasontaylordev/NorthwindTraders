import { NgModule } from '@angular/core';

import { FeatherModule } from 'angular-feather';
import { Home, File, ShoppingCart, Users, BarChart2, Layers, PlusCircle, FileText } from 'angular-feather/icons';

const icons = {
    Home, File, ShoppingCart, Users, BarChart2, Layers, PlusCircle, FileText
};

@NgModule({
    imports: [
        FeatherModule.pick(icons)
    ],
    exports: [
        FeatherModule
    ]
})
export class AppIconsModule { }
