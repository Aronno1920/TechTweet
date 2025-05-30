import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category-service';
import { Category } from '../models/category.model';
import { FormsModule } from '@angular/forms';
import { CategoryUpdateRequest } from '../models/category-update-request';
import { Router } from '@angular/router';


@Component({
  selector: 'app-category-edit',
  standalone:true,
  imports: [FormsModule, CommonModule],
  templateUrl: './category-edit.html',
  styleUrl: './category-edit.css'
})
export class CategoryEdit implements OnInit, OnDestroy {
  
  id:string | null=null;
  paramsSubscription ?: Subscription;
  category?: Category;
  
  constructor(
    private route: ActivatedRoute, 
    private cService: CategoryService, 
    private router: Router){
    }


  ngOnInit(): void {
    this.paramsSubscription= this.route.paramMap.subscribe({
      next:(params)=>{
        this.id=params.get('id');

        if(this.id){
          this.cService.getCategoryById(this.id).subscribe({
            next:(response) =>{
              console.log(response);
              this.category=response;
            }
          })
        }
      }
    })
  }

  OnFormSubmit():void{
    const categoryUpdate:CategoryUpdateRequest = {
      name:this.category?.name?? '',
      urlHandle:this.category?.urlHandle ?? ''
    };

    if(this.id){
      this.cService.updateCategory(this.id, categoryUpdate).subscribe(
        {
          next: (response) =>{
            this.router.navigateByUrl('');
          }
        });
    }
  }

    ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
  }
}
