
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { Materias } from '../interfaces/Materias';
import { HttpClient } from '@angular/common/http';
import { CrearMateriaDto } from '../interfaces/CrearMateriaDto';

@Injectable({
  providedIn: 'root',
})
export class MateriaService {


  private ApiUrl: string = `${environment.apiUrl}/Materia`;

  constructor(

    private http: HttpClient

  ) {

  }

  getAll(): Observable<Materias[]> {

    return this.http.get<Materias[]>(this.ApiUrl);

  }

  getById(id: number): Observable<Materias> {

    return this.http.get<Materias>(`${this.ApiUrl}/${id}`);

  }

  CrearMateria(materia : CrearMateriaDto): Observable<Materias>{

    return this.http.post<Materias>(this.ApiUrl, materia);

  }





}
