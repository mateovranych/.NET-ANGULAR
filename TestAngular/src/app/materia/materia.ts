import { Component, OnInit } from '@angular/core';
import { MateriaService } from '../services/materia-service';
import { Materias } from '../interfaces/Materias';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogAgregarMateria } from '../dialog-agregar-materia/dialog-agregar-materia';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-materia',
  standalone: true,

  imports: [

    CommonModule,
    MatTableModule

  ],

  templateUrl: './materia.html',
  styleUrl: './materia.scss',
})
export class Materia implements OnInit {

  materia: Materias[] = [];
  displayedColumns: string[] = ['id', 'nombre', 'acciones'];

  constructor(

    //ACA DELCARAMOS EL SERVICIO PARA PODER UTILIZARLO EN LOS MÉTODOS

    private materiaService: MateriaService,
    private dialog: MatDialog

  ) {

  }

  ngOnInit(): void {
        
    //ACÁ INICIALIZAMOS EL MÉTODO, Y SIRVE PARA CARGAR LA TABLITA
    this.cargarMaterias();

  }

  cargarMaterias() {

    this.materiaService.getAll().subscribe({

      next: (data) => this.materia = data,

      error: (err) => {
        console.error('err', err)
      },

    })

  }

  agregarMateria() {

    const dialogRef = this.dialog.open(DialogAgregarMateria, {
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {

      if (!result)
        return;

      this.materiaService.CrearMateria(result).subscribe({

        next: () => {

          //EL CASO DE EXITO, ES EL NEXT

          // Swal.fire('Listo', 'Materia agregado correctamente.', 'success');

          console.log('Materia agregada correctamente')

          this.cargarMaterias();

        },

        

        error: () => Swal.fire('Error', 'No se pudo agregar la materia.', 'error')

        //EL CASO DE ERROR ES CUANDO FALLA

      });
    });

    return console.log('Con este boton vamos a crear la materia, el backend ya tiene ese endpoint funcionando correctamente')

  }


  eliminar(materia: Materia) {

    return console.log('Con este boton se elimina la materia // OJO de hacer funcionar el getbyId del backend')

  }

  editarMateria(materia: Materia) {

    return console.log('Con este boton se edita la materia')

  }

}
