import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../services/category-service';
import { Category } from '../models/category.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-category-list',
  standalone:true,
  imports: [CommonModule, RouterLink],
  templateUrl: './category-list.html',
  styleUrl: './category-list.css'
})

export class CategoryList implements OnInit{
  categories$?: Observable<Category[]>;

  constructor(private _cService:CategoryService){
  }

  ngOnInit(): void {
    this.categories$ = this._cService.getAllCategories();

    console.log('-------> ', this.categories$)
  }
}
