import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from './core/components/navbar/navbar';

@Component({
  selector: 'app-root',
  standalone:true,
  imports: [RouterOutlet, Navbar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'TechTweetUI';
}
