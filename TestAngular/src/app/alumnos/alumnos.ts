import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Alumno } from '../interfaces/Alumno';
import { alumnosService } from '../services/AlumnoService';
import Swal from 'sweetalert2';
import { AlumnoDialogComponent } from '../dialog-agregar-alumno/dialog-agregar-alumno';

@Component({
  selector: 'app-alumnos',
  standalone: true,
  imports: [

    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule
  ],
  templateUrl: './alumnos.html',
  styleUrl: './alumnos.scss',
})
export class AlumnosComponent implements OnInit {

  alumnos: Alumno[] = [];
  displayedColumns: string[] = ['id', 'nombre', 'email', 'materia', 'acciones'];

  constructor(
    private alumnosService: alumnosService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.cargarAlumnos();
  }

  cargarAlumnos() {
    this.alumnosService.getAll().subscribe({

      next: (data) => this.alumnos = data,

      error: (err) => {
        console.error('Error al traer alumnos', err);
        Swal.fire('Error', 'No se pudieron cargar los alumnos porque se cayo el servidor.', 'error');
      },

    });
  }

  agregarAlumno() {

    const dialogRef = this.dialog.open(AlumnoDialogComponent, {
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        return;

      this.alumnosService.create(result).subscribe({

        next: () => {
          Swal.fire('Listo', 'Alumno agregado correctamente.', 'success');
          this.cargarAlumnos();
        },

        error: () => Swal.fire('Error', 'No se pudo agregar el alumno.', 'error')

      });
    });

  }

  editarAlumno(alumno: Alumno) {

    const dialogRef = this.dialog.open(AlumnoDialogComponent, {
      data: { alumno }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result) return;

      this.alumnosService.update(alumno.id, result).subscribe({
        next: () => {

          Swal.fire('Guardado', 'Alumno actualizado correctamente.', 'success');
          this.cargarAlumnos();

        },
        error: () => Swal.fire('Error', 'No se pudo actualizar el alumno.', 'error')
      });
    });

  }

  eliminar(alumno: Alumno) {
    Swal.fire({
      title: '¿Eliminar alumno?',
      text: `Vas a eliminar a ${alumno.nombre}. Esta acción no se puede deshacer.`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#d33',
      confirmButtonText: 'Sí, eliminar',
      cancelButtonText: 'Cancelar'
    }).then(result => {
      if (!result.isConfirmed) return;

      this.alumnosService.delete(alumno.id).subscribe({
        next: () => {
          Swal.fire('Eliminado', 'El alumno fue eliminado.', 'success');
          this.cargarAlumnos();
        },
        error: () => Swal.fire('Error', 'No se pudo eliminar el alumno.', 'error')
      });
    });
  }
}