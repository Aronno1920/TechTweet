import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms'

@Component({
  selector: 'app-category-add',
  standalone:true,
  imports: [RouterLink, FormsModule],
  templateUrl: './category-add.component.html',
  styleUrl: './category-add.component.css'
})


export class CategoryAddComponent {

}
