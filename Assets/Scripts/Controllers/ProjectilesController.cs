using PixelGame.Enumerators;
using PixelGame.Model;
using PixelGame.Model.Utils;
using PixelGame.View;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class ProjectilesController
    {
        private ProjectileView _projectilePrefab;

        private List<ProjectileModel> _projectiles;

        private ViewService _projectileViewService;

        private float _projectilLifeTime;

        public ProjectilesController(ProjectileType projectileType, float ptjtLeifeTime, ViewService viewService) 
        {
            _projectilePrefab = Resources.Load<ProjectileView>($"{projectileType}Projectile");

            if (!_projectilePrefab)
            {
                Debug.LogError($"Can't find Resource {projectileType}Projectile");
            }

            _projectileViewService = viewService;

            _projectiles = new List<ProjectileModel>();

            _projectilLifeTime = ptjtLeifeTime;
        }

        public void Update(float time) 
        {
            foreach(var projectile in _projectiles.ToArray()) 
            {
                if(projectile.LifeTime > _projectilLifeTime) 
                {
                    Remove(projectile);
                }
                projectile.LifeTime += time;
            }
        }

        public ProjectileModel Add(float damage, Vector3 startPosition) 
        {
            var prjOb = _projectileViewService.Instantiate<ProjectileView>(_projectilePrefab);
            
            prjOb.Transform.position = startPosition;
            prjOb.Transform.rotation = Quaternion.identity;

            var model = new ProjectileModel(damage, prjOb, Remove);

            _projectiles.Add(model);
            
            return model;
        }

        public void Remove(ProjectileModel model) 
        {
            _projectiles.Remove(model);
            _projectileViewService.Destroy(model.View);
            model.Dispose();
        }
    }
}
