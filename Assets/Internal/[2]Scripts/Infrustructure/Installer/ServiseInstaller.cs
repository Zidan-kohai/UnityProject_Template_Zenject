using Infrustructure.Service.CoroutineController;
using Infrustructure.Service.Factory;
using Infrustructure.Service.Input;
using Infrustructure.Service.SceneLoader;
using Runtime.Curtain;
using System;
using UnityEngine;
using Zenject;

namespace Infrustructure.Installer
{

    [CreateAssetMenu(fileName = "ServiseInstaller", menuName = "Installers/ServiseInstaller")]
    public class ServiseInstaller : ScriptableObjectInstaller<ServiseInstaller>
    {
        [SerializeField] private Curtain _curtainPrefab;

        public override void InstallBindings()
        {
            BindInput();

            BindCoroutineRunner();

            BindFactory();

            BindCurtain();

            BindSceneLoader();
        }

        private void BindInput()
        {
            this.Container.Bind<IInput>()
                .To<DesctopInput>()
                .AsSingle();
        }

        private void BindFactory()
        {
            this.Container
                .Bind<Service.Factory.IFactory>()
                .To<Factory>()
                .AsSingle();
        }

        private void BindSceneLoader()
        {
            this.Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();
        }

        private void BindCurtain()
        {
            this.Container
                .Bind<ICurtain>()
                .To<Curtain>()
                .FromComponentInNewPrefab(_curtainPrefab)
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            this.Container
                .Bind<ICoroutineController>()
                .To<CoroutineController>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}