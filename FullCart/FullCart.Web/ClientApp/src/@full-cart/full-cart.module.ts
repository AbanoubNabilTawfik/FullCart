import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FullCartRoutingModule } from './full-cart-routing.module';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FullCartRoutingModule,
    HttpClientModule
  ]
})
export class FullCartModule { }
