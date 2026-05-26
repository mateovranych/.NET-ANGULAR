import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Footer } from './footer/footer';
import { Header } from './header/header';
import { Home } from './home/home';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,
            Footer,
            Header,
            Home
            


  ],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'TestAngular';
}
