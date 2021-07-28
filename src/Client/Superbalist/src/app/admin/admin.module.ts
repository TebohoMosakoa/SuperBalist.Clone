import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './product/products/products.component';
import { PromotionsComponent } from './promotion/promotions/promotions.component';
import { OrdersComponent } from './order/orders/orders.component';
import { CategoriesComponent } from './product/categories/categories.component';
import { BrandsComponent } from './product/brands/brands.component';
import { DepartmentsComponent } from './product/departments/departments.component';
import { UsersComponent } from './users/users.component';
import { DiscountsComponent } from './discounts/discounts.component';
import { LayoutComponent } from './shared/layout/layout.component';
import { RouterModule, Routes } from '@angular/router';
import { SideComponent } from './shared/side/side.component';

const routes: Routes = [
  { path: '', component: HomeComponent},
      { path: 'Home', component: HomeComponent },
      { path: 'Products', component: ProductsComponent },
      { path: 'Promotions', component: PromotionsComponent },
      { path: 'Orders', component: OrdersComponent },
      { path: 'Categories', component: CategoriesComponent },
      { path: 'Brands', component: BrandsComponent },
      { path: 'Departments', component: DepartmentsComponent },
      { path: 'Users', component: UsersComponent },
      { path: 'Discounts', component: DiscountsComponent }
];

@NgModule({
  declarations: [
    HomeComponent,
    ProductsComponent,
    PromotionsComponent,
    OrdersComponent,
    CategoriesComponent,
    BrandsComponent,
    DepartmentsComponent,
    UsersComponent,
    DiscountsComponent,
    LayoutComponent,
    SideComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class AdminModule { }
