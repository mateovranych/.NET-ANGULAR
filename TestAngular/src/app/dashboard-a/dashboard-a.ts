import { Component } from '@angular/core';
import { RouterModule } from "@angular/router";
import { AlumnosComponent } from "../alumnos/alumnos";

@Component({
  selector: 'app-dashboard-a',
  standalone:true,
  imports: [RouterModule, 
    AlumnosComponent],
  templateUrl: './dashboard-a.html',
  styleUrl: './dashboard-a.scss',
})
export class DashboardA {

}
