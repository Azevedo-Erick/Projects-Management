import 'dart:io';

import 'package:dio/dio.dart';

import '../models/city_model.dart';

class CityRepository {
  final Dio dio;
  CityRepository({required this.dio});

  Future<List<CityModel>> getAll() async {
    final result = await dio.get('https://localhost:7289/v1/cities');
    final List<CityModel> projects = [];
    sleep(const Duration(seconds: 5));
    if (result.statusCode == 200) {
      result.data["data"]
          .map((item) => projects.add(CityModel.fromMap(item)))
          .toList();
    }
    return projects;
  }
}
