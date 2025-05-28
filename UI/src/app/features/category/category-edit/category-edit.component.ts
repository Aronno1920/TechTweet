import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-category-edit',
  standalone:true,
  imports: [FormsModule, CommonModule],
  templateUrl: './category-edit.component.html',
  styleUrl: './category-edit.component.css'
})
export class CategoryEditComponent implements OnInit, OnDestroy {
  
  id:string | null=null;
  paramsSubscription ?: Subscription;
  category?: Category;
  
  constructor(private route:ActivatedRoute, private cService:CategoryService){

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
    console.log(this.category);

  }

    ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
  }
}
