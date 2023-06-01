import 'package:dio/dio.dart';

import '../models/project_model.dart';

class ProjectRepository {
  final Dio dio;

  ProjectRepository({required this.dio});

  Future<List<ProjectModel>> getProjects() async {
    final result = await dio.get('https://localhost:7289/v1/projects');
    final List<ProjectModel> projects = [];
    if (result.statusCode == 200) {
      result.data["data"][0]
          .map((item) => projects.add(ProjectModel.fromMap(item)));
    }
    return projects;
  }
}
