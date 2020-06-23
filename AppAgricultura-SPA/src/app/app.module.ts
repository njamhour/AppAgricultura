import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegistrarComponent } from './registrar/registrar.component';
import { AlertifyService } from './_services/alertify.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { ListarUsuariosComponent } from './listar-usuarios/listar-usuarios.component';
import { ListasComponent } from './listas/listas.component';
import { MensagensComponent } from './mensagens/mensagens.component';
import { appRoutes } from './routes';
import { AuthGuard } from './_guards/auth.guard';



@NgModule({
   declarations: [
      AppComponent,
      UsuarioComponent,
      HomeComponent,
      NavComponent,
      RegistrarComponent,
      ListarUsuariosComponent,
      ListasComponent,
      MensagensComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService,
      AuthGuard
   ],
   bootstrap: [
      AppComponent
   ],
})
export class AppModule { }
