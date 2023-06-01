import 'package:dio/dio.dart';
import 'package:frontend/data/repositories/project_repository.dart';
import 'package:get/get.dart';

import '../../controllers/projects_controller.dart';

setupProjects() {
  Get.put<ProjectsController>(
      ProjectsController(projectRepository: ProjectRepository(dio: Dio())));
}
