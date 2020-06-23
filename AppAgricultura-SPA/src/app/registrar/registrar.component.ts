import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
// import { EventEmitter } from 'protractor';


@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css']
})
export class RegistrarComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  registrar() {
    this.authService.register(this.model).subscribe(() => {
      console.log('Registrado com sucesso');
    }, error => {
      console.log(error);
    });
  }

  cancelar() {
    this.cancelRegister.emit(false);
    console.log('Cancelado');
  }

}
