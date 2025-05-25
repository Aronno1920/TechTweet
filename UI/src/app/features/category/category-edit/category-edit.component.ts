import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-category-edit',
  standalone:true,
  imports: [],
  templateUrl: './category-edit.component.html',
  styleUrl: './category-edit.component.css'
})
export class CategoryEditComponent implements OnInit {
  
  id:string | null=null;
  paramsSubscription ?: Subscrition;



  constructor(private route:ActivatedRoute){

  }
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        this.id=params.get('id');
      }
    })
  }
}
