import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatDividerModule } from '@angular/material/divider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AddSafetyDocumentComponent } from './add-safety-document/add-safety-document.component';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { SafetyDocumentViewComponent } from './safety-document-view/safety-document-view.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AddWorkingPlanComponent } from './add-working-plan/add-working-plan.component';

import { MatFormFieldModule } from '@angular/material/form-field';

import { MatCheckboxModule } from '@angular/material/checkbox';

import { AddSwitchingPlanComponent } from './add-switching-plan/add-switching-plan.component';
import { IncidentsViewComponent } from './incidents-view/incidents-view.component';
import { AddIncidentComponent } from './add-incident/add-incident.component';
import { ViewSwitchingPlanComponent } from './view-switching-plan/view-switching-plan.component';
import { ViewWorkingPlanComponent } from './view-working-plan/view-working-plan.component';
import { AddConsumerComponent } from './add-consumer/add-consumer.component';
import { ViewConsumersComponent } from './view-consumers/view-consumers.component';
import { AddCrewComponent } from './add-crew/add-crew.component';
import { AddCrewMemberComponent } from './add-crew-member/add-crew-member.component';
import { ViewCrewComponent } from './view-crew/view-crew.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    AddSafetyDocumentComponent,
    SafetyDocumentViewComponent,
    AddWorkingPlanComponent,
    AddSwitchingPlanComponent,
    IncidentsViewComponent,
    AddIncidentComponent,
    ViewSwitchingPlanComponent,
    ViewWorkingPlanComponent,
    AddConsumerComponent,
    ViewConsumersComponent,
    AddCrewComponent,
    AddCrewMemberComponent,
    ViewCrewComponent
  ],
  imports: [
    MatPaginatorModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatInputModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatDividerModule,
    MatSlideToggleModule,
    MatSelectModule,
    MatOptionModule,
    MatProgressSpinnerModule,
    HttpClientModule
],
exports: [ MatFormFieldModule, MatInputModule ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
