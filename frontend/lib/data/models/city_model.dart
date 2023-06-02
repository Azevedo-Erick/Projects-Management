// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'state_model.dart';

class CityModel {
  final int id;
  final String name;
  final StateModel? state;

  CityModel({
    required this.id,
    required this.name,
    this.state,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'name': name,
      'state': state?.toMap(),
    };
  }

  factory CityModel.fromMap(Map<String, dynamic> map) {
    return CityModel(
      id: map['id'] as int,
      name: map['name'] as String,
      state: map['state'] != null
          ? StateModel.fromMap(map['state'] as Map<String, dynamic>)
          : null,
    );
  }

  String toJson() => json.encode(toMap());

  factory CityModel.fromJson(String source) =>
      CityModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
