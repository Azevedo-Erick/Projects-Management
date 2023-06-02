import 'dart:io';

import 'package:dio/dio.dart';

import '../models/state_model.dart';

class StateRepository {
  final Dio dio;
  StateRepository({required this.dio});

  Future<List<StateModel>> getAll() async {
    final result = await dio.get('https://localhost:7289/v1/cities');
    final List<StateModel> states = [];
    sleep(const Duration(seconds: 5));
    if (result.statusCode == 200) {
      result.data["data"]
          .map((item) => states.add(StateModel.fromMap(item)))
          .toList();
    }
    return states;
  }
}
