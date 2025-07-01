import { Component, OnInit } from '@angular/core';
import { BlogPostAdd } from '../models/blog-post-add.model';
import { RouterLink, Router } from '@angular/router';
import { FormsModule } from '@angular/forms'
import { BlogPostService } from '../services/blog-post.service';
import { response,  } from 'express';

@Component({
  selector: 'app-post-add',
  standalone: true,
  imports: [RouterLink, FormsModule],
  templateUrl: './post-add.component.html',
  styleUrls: ['./post-add.component.css']
})
export class PostAddComponent implements OnInit {

  model:BlogPostAdd;

  constructor(private blogPostService : BlogPostService, 
    private router: Router) { 
    this.model = {
      title:'',
      shortDescription:'',
      content:'',
      imageUrl:'',
      urlHandle:'',
      author:'',
      isPublished:true,
      createdDate:new Date()
    }
  }

  ngFormSubmit():void{
    this.blogPostService.createBlogPost(this.model)
    .subscribe({
      next:(response) => {
        this.router.navigateByUrl('/admin/posts');
      }
    });
  }

  ngOnInit() {
  }
    
}
