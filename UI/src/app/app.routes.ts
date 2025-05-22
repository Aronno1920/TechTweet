import { Routes, RouterModule } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { HomeComponent } from './features/public/home/home.component';

export const routes: Routes = [
     {path:'', component:HomeComponent},
     {path:'admin/categories', component:CategoryListComponent}
];

export class AppRoutingModule{}
