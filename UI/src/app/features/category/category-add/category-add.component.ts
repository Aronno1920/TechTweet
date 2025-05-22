import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms'
import { CategoryAddRequest } from '../models/category-add-request.model';

@Component({
  selector: 'app-category-add',
  standalone:true,
  imports: [RouterLink, FormsModule],
  templateUrl: './category-add.component.html',
  styleUrl: './category-add.component.css'
})


export class CategoryAddComponent {

  model: CategoryAddRequest;

  constructor(){
    this.model={
      name:'',
      urlHandle:''
    };
  }

  onFormSubmit(){
    console.log(this.model);
  }
}
