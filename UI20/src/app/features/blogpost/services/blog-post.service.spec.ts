import { TestBed } from '@angular/core/testing';
import { BlogPostService } from './blog-post.service';


describe('PostService', () => {
  let service: BlogPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BlogPostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
