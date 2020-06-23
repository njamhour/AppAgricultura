import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
// import { EventEmitter } from 'protractor';


@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css']
})
export class RegistrarComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  registrar() {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('Registrado com sucesso');
    }, error => {
      this.alertify.error(error);
    });
  }

  cancelar() {
    this.cancelRegister.emit(false);
    // this.alertify.error('Cancelado');
  }

}
