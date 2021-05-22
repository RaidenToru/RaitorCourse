import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MaterialModule} from './material/material.module';
import { LoginComponent } from './components/authorization/login/login.component';
import {HeaderComponent} from './components/layout/header/header.component';
import {RegistrationComponent} from './components/authorization/registration/registration.component';
import {NotFoundComponent} from './components/not-found/not-found.component';
import {UserInfoComponent} from './components/user-profile/user-info/user-info.component';
import {UserCoursesComponent} from './components/user-profile/user-courses/user-courses.component';
import {UserInfoEditComponent} from './components/user-profile/user-info-edit/user-info-edit.component';
import {ProfileComponent} from './components/user-profile/profile/profile.component';
import {AdminProfileComponent} from './components/admin-profile/admin-profile.component';
import {FooterComponent} from './components/layout/footer/footer.component';
import {CategoriesComponent} from './components/categories/categories.component';
import {CourseComponent} from './components/course-learn/course/course.component';
import {AssessmentTaskComponent} from './components/course-learn/assessment-task/assessment-task.component';
import {CourseDetailedComponent} from './components/course-learn/course-detailed/course-detailed.component';
import {SubcategoryComponent} from './components/subcategory/subcategory.component';
import {TaskComponent} from './components/course-learn/task/task.component';
import {SearchComponent} from './components/search/search.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MainComponent} from './components/main/main.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    RegistrationComponent,
    NotFoundComponent,
    UserInfoComponent,
    UserCoursesComponent,
    UserInfoEditComponent,
    ProfileComponent,
    AdminProfileComponent,
    FooterComponent,
    CategoriesComponent,
    SearchComponent,
    CourseComponent,
    TaskComponent,
    AssessmentTaskComponent,
    SubcategoryComponent,
    CourseDetailedComponent,
    MainComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
