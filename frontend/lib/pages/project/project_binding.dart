import 'package:dio/dio.dart';
import 'package:get/get.dart';

import '../../controllers/project_controller.dart';
import '../../data/repositories/project_repository.dart';

setupProject() {
  Get.put<ProjectController>(
      ProjectController(projectRepository: ProjectRepository(dio: Dio())));
}
