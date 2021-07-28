import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './general/home/home.component';
const routes: Routes = [
  { path: '', component: HomeComponent},
  {
    path: 'Home',
    loadChildren: () => import('./general/general.module').then(m => m.GeneralModule)
},
{
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
},
{
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
