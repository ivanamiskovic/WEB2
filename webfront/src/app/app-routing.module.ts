import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSwitchingPlanComponent } from './add-switching-plan/add-switching-plan.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'add-switchinng-plan', component: AddSwitchingPlanComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
