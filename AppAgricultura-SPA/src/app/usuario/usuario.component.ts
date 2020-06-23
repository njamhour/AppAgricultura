import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {
  usuarios: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getUsuarios();
  }

  getUsuarios() {
    this.http.get('http://localhost:5000/api/values').subscribe(response => {
      this.usuarios = response;
    }, error => {
      console.log(error);
    });
  }

}
