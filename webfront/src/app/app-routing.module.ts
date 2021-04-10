import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddWorkingPlanComponent } from './add-working-plan/add-working-plan.component';
import { AddSwitchingPlanComponent } from './add-switching-plan/add-switching-plan.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'add-working-plan', component: AddWorkingPlanComponent },
  { path: 'add-switchinng-plan', component: AddSwitchingPlanComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
