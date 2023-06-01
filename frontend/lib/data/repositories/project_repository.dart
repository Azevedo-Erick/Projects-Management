import 'dart:io';

import 'package:dio/dio.dart';

import '../models/project_model.dart';

class ProjectRepository {
  final Dio dio;

  ProjectRepository({required this.dio});

  Future<List<ProjectModel>> getProjects() async {
    final result = await dio.get('https://localhost:7289/v1/projects');
    final List<ProjectModel> projects = [];
    sleep(const Duration(seconds: 5));
    if (result.statusCode == 200) {
      result.data["data"]
          .map((item) => projects.add(ProjectModel.fromMap(item)))
          .toList();
    }
    return projects;
  }

  Future<ProjectModel> getProject({required int id}) async {
    final result =
        await dio.get('https://localhost:7289/v1/projects/${id.toString()}');
    late ProjectModel project;
    sleep(const Duration(seconds: 5));
    if (result.statusCode == 200) {
      project = ProjectModel.fromMap(result.data["data"][0]);
    }
    return project;
  }
}
