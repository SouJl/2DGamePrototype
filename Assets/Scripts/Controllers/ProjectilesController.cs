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

        public ProjectilesController(ProjectileType projectileType, ViewService projectileViewService) 
        {
            _projectilePrefab = Resources.Load<ProjectileView>($"{projectileType}Projectile");

            if (!_projectilePrefab)
            {
                Debug.LogError($"Can't find Resource {projectileType}Projectile");
            }

            _projectileViewService = projectileViewService;

            _projectiles = new List<ProjectileModel>();
        }


        public ProjectileModel Add(float damage) 
        {
            var prjOb = _projectileViewService.Instantiate<ProjectileView>(_projectilePrefab);

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
