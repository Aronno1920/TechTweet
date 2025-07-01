import { Routes } from '@angular/router';
import { CategoryList } from './features/category/category-list/category-list';
import { Home } from './features/public/home/home';
import { CategoryAdd } from './features/category/category-add/category-add';
import { CategoryEdit } from './features/category/category-edit/category-edit';
import { PostListComponent } from './features/blogpost/post-list/post-list.component';
import { PostAddComponent } from './features/blogpost/post-add/post-add.component';
import { PostEditComponent } from './features/blogpost/post-edit/post-edit.component';


export const routes: Routes = [
     {path:'', component:Home},
     {path:'admin/categories', component:CategoryList},
     {path:'admin/categories/add', component:CategoryAdd},
     {path:'admin/categories/:id', component:CategoryEdit, runGuardsAndResolvers: 'always'},

     {path:'admin/posts', component:PostListComponent},
     {path:'admin/posts/add', component:PostAddComponent},
     {path:'admin/posts/edit', component:PostEditComponent}
];

export class AppRoutingModule{}
