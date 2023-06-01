// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class ProjectModel {
  final int id;
  final String name;
  final String release;

  ProjectModel({required this.name, required this.id, required this.release});

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'name': name,
      'release': release,
    };
  }

  factory ProjectModel.fromMap(Map<String, dynamic> map) {
    return ProjectModel(
      id: map['id'] as int,
      name: map['name'] as String,
      release: map['release'] as String,
    );
  }

  String toJson() => json.encode(toMap());

  factory ProjectModel.fromJson(String source) =>
      ProjectModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
