import { Component, OnDestroy } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms'
import { CategoryAddRequest } from '../models/category-add-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category-add',
  standalone:true,
  imports: [RouterLink, FormsModule],
  templateUrl: './category-add.html',
  styleUrl: './category-add.css'
})

export class CategoryAdd implements OnDestroy {

  model: CategoryAddRequest;
  private CategoryAddSubcription?:Subscription;

  constructor(private categoryService: CategoryService, private router:Router){
    this.model={
      name:'',
      urlHandle:''
    };
  }

  onFormSubmit(){
    this.CategoryAddSubcription = this.categoryService.addCategory(this.model).subscribe({
      next:(response) =>{
        this.router.navigateByUrl('/admin/categories');
      },
      error:(response)=>{
      }
    });
  }

  ngOnDestroy(): void {
    this.CategoryAddSubcription?.unsubscribe();
  }
}
