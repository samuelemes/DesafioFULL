import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent, ResetPasswordFormComponent, CreateAccountFormComponent, ChangePasswordFormComponent } from './shared/components';
import { AuthGuardService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { TitulosEmAtrasoComponent } from './pages/titulos-em-atraso/titulos-em-atraso.component';
import { DxDataGridModule, DxFormModule } from 'devextreme-angular';
import { FaturasComponent } from './pages/faturas/faturas.component';
import { TitulosAVencerComponent } from './pages/titulos-a-vencer/titulos-a-vencer.component';

const routes: Routes = [
  {
    path: 'titulos-em-atraso',
    component: TitulosEmAtrasoComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'titulos-a-vencer',
    component: TitulosAVencerComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'faturas',
    component: FaturasComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'reset-password',
    component: ResetPasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'create-account',
    component: CreateAccountFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'change-password/:recoveryCode',
    component: ChangePasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true }), DxDataGridModule, DxFormModule],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [HomeComponent, TitulosEmAtrasoComponent, TitulosAVencerComponent, FaturasComponent]
})
export class AppRoutingModule { }
