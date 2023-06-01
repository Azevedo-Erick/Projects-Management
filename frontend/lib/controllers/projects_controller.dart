import 'package:frontend/data/models/project_model.dart';
import 'package:frontend/data/repositories/project_repository.dart';
import 'package:get/get.dart';

class ProjectsController extends GetxController {
  final ProjectRepository projectRepository;

  final List<ProjectModel> _projects = <ProjectModel>[].obs;
  final RxBool _isLoading = false.obs;

  List<ProjectModel> get projects => _projects;
  RxBool get isLoading => _isLoading;

  ProjectsController({required this.projectRepository});

  getProjects() async {
    _isLoading.value = true;

    final response = await projectRepository.getProjects();

    _projects.addAll(response);

    _isLoading.value = false;
  }
}
