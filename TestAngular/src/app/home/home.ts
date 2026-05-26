import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import {MatButtonModule} from '@angular/material/button';



@Component({
  selector: 'app-home',
  standalone:true,
  imports: [
    RouterModule,
    MatButtonModule
    
  ],

  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {

  constructor(

    private router: Router


  ) 

  {

  }


  //SE PUEDE NAVEGAR DE LAS DOS FORMAS ROUTERLINK, ES MAS SIMPLE Y DECLARATIVO O CON EL NAVITAGE PERO NECESITAS LOGICA ANTES EJ VALIDACIONES.

  navegarAlDashboardB() {

    this.router.navigate(['/dashboardB'])
    
  }

  navegarAlDashboardC(){

    this.router.navigate(['/dashboardC'])
    
  }

}
