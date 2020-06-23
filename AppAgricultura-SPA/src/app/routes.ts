import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListarUsuariosComponent } from './listar-usuarios/listar-usuarios.component';
import { MensagensComponent } from './mensagens/mensagens.component';
import { ListasComponent } from './listas/listas.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'usuarios', component: ListarUsuariosComponent },
            {path: 'mensagens', component: MensagensComponent },
            {path: 'listas', component: ListasComponent },
        ]
    },
    {path: '**', redirectTo: 'home', pathMatch: 'full'},
];
