import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';


@Component({
  selector: 'app-category-list',
  standalone:true,
  imports: [CommonModule, RouterLink],
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})

export class CategoryListComponent implements OnInit{
  
  categories: Category[] = [];

  constructor(private _cService:CategoryService){
  }

  ngOnInit(): void {
    this._cService.getAllCategories()
    .subscribe({
      next:(response) =>{
        this.categories = response;
      }
    });
  }
}
