import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Auth/login/login.component';
import { AdminNavComponent } from './Admin/admin-nav/admin-nav.component';
import { ItemListComponent } from './Admin/item-list/item-list.component';
import { BrandListComponent } from './Admin/brand-list/brand-list.component';
import { CategoryListComponent } from './Admin/category-list/category-list.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    AdminNavComponent,
    ItemListComponent,
    BrandListComponent,
    CategoryListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent},
      { path: 'item-list', component: ItemListComponent},
      { path: 'brand-list', component: BrandListComponent},
      { path: 'category-list', component: CategoryListComponent},

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
